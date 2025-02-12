using System.Threading;
using PhonewordGenerator.BLM;

namespace PhonewordGenerator.UI
{
    public partial class MainForm : Form
    {
        private List<string> _dictionaryWords; // List to hold dictionary words
        private const int maxResultsToDisplay = 1000; // Max number of results to display
        private List<string> _allGeneratedPhonewords = new List<string>(); // Store all generated phonewords
        private CancellationTokenSource _cancellationTokenSource; // For cancelling async tasks
        public MainForm()
        {
            InitializeComponent();
            LoadDictionary();
        }
        private void LoadDictionary()
        {
            try
            {
                // Construct the path to the dictionary file
                string dictPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionary.txt");
                _dictionaryWords = new List<string>(File.ReadAllLines(dictPath));
                // Convert words to uppercase to ensure case-insensitive matching, JUST IN CASE.
                for (int i = 0; i < _dictionaryWords.Count; i++)
                {
                    _dictionaryWords[i] = _dictionaryWords[i].ToUpperInvariant();
                }
            }
            catch (Exception ex)
            {
                // Show an error message if the dictionary fails to load
                MessageBox.Show($"Error loading dictionary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGenerate.Enabled = false;
            }
        }

        // Event handler to ensure only digits are entered in the phone number textbox
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Discard the input
            }
        }

        // Event handler to remove any non-digit characters from the phone number textbox (in case they are pasted)
        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            // Remove any non-digit characters
            string digitsOnly = new string(txtPhoneNumber.Text.Where(char.IsDigit).ToArray());
            if (txtPhoneNumber.Text != digitsOnly)
            {
                // Adjust cursor position after removing invalid characters
                int selectionStart = txtPhoneNumber.SelectionStart - (txtPhoneNumber.Text.Length - digitsOnly.Length);
                txtPhoneNumber.Text = digitsOnly;
                txtPhoneNumber.SelectionStart = selectionStart >= 0 ? selectionStart : 0;
            }
        }

        // Event handler to ensure only letters are entered in the word input textbox
        private void txtWordInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Event handler to convert word input text to uppercase
        private void txtWordInput_TextChanged(object sender, EventArgs e)
        {
            
            txtWordInput.Text = txtWordInput.Text.ToUpperInvariant();
            txtWordInput.SelectionStart = txtWordInput.Text.Length;

        }
        // Event handler to ensure only letters and newlines are entered in the custom words textbox
        private void txtCustomWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '\n' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }
        }

        // Event handler to filter invalid characters and convert to uppercase in custom words textbox
        private void txtCustomWords_TextChanged(object sender, EventArgs e)
        {
            // Filter out invalid characters and convert to uppercase
            string filteredText = new string(txtCustomWords.Text.Where(c => char.IsLetter(c) || c == '\n' || c == '\r').ToArray());
            if (txtCustomWords.Text != filteredText)
            {
                // Adjust cursor position after removing invalid character
                int selectionStart = txtCustomWords.SelectionStart - (txtCustomWords.Text.Length - filteredText.Length);
                txtCustomWords.Text = filteredText;
                txtCustomWords.SelectionStart = selectionStart >= 0 ? selectionStart : 0;
            }
            else
            {
                // Convert to uppercase
                txtCustomWords.Text = txtCustomWords.Text.ToUpperInvariant();
                txtCustomWords.SelectionStart = txtCustomWords.Text.Length; // Move cursor to the end
            }
        }
        
        // Async event handler for the Generate button click
        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            txtSearchGenerated.Clear();
            txtSearchGenerated.Enabled = false;
            txtSearchGenerated.Clear();
            string number = txtPhoneNumber.Text.Trim();

            if (IsValidPhoneNumber(number))
            {
                var customWords = GetCustomWords(); // Retrieve custom words input by the user

                progressBar.Visible = true; // Show progress bar
                btnCancel.Enabled = true;// Enable Cancel Button
                statusLabel.Text = "Generating phonewords...";

                _cancellationTokenSource = new CancellationTokenSource(); // Initialize cancellation token

                var phonewordService = new PhonewordService();

                try
                {
                    // Run the phoneword generation in a separate task
                    var results = await Task.Run(() =>
                        phonewordService.GeneratePhonewords(number, _dictionaryWords, customWords, _cancellationTokenSource.Token));

                    _allGeneratedPhonewords = results; // Store all results for searching

                    // Limit the number of results to display
                    var resultsToDisplay = results.Take(maxResultsToDisplay).ToList();

                    lstGenerated.Items.Clear();
                    lstGenerated.Items.AddRange(resultsToDisplay.ToArray());

                    txtSearchGenerated.Enabled = lstGenerated.Items.Count > 0;

                    // Inform the user if the generation limit was reached
                    if (phonewordService.GenerationLimitReached)
                    {
                        MessageBox.Show(
                            $"Generation limit of {PhonewordGenerator.BLM.PhonewordGenerator.MaxCombinations} combinations reached. The results may be incomplete.\nDisplaying {resultsToDisplay.Count} out of {results.Count} generated results.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else if (results.Count > maxResultsToDisplay)
                    {
                        // Inform the user if not all results are displayed
                        MessageBox.Show(
                            $"Displaying the first {maxResultsToDisplay} results out of {results.Count} generated. Please refine your input for more specific results.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    statusLabel.Text = "Generation complete.";
                }
                catch (OperationCanceledException)
                {
                    statusLabel.Text = "Generation canceled.";
                    txtSearchGenerated.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = "Error occurred during generation.";
                    txtSearchGenerated.Enabled = false;
                }
                finally
                {
                    progressBar.Visible = false;
                    btnCancel.Enabled = false;
                    _cancellationTokenSource = null;
                }
            }
        }
        private bool IsValidPhoneNumber(string number)
        {
            // Ensures the number is not empty and contains only digits
            return !string.IsNullOrEmpty(number) && number.All(char.IsDigit);
        }

        private List<string> GetCustomWords()
        {
            var customWords = new List<string>();

            // Get the text from txtCustomWords
            string[] lines = txtCustomWords.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string word = line.Trim().ToUpperInvariant();
                if (IsValidCustomWord(word))
                {
                    customWords.Add(word);
                }
            }

            return customWords;
        }

        private bool IsValidCustomWord(string word)
        {
            // Ensures the word contains only letters A-Z
            return !string.IsNullOrEmpty(word) && word.All(c => c >= 'A' && c <= 'Z');
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            btnCancel.Enabled = false;
            txtSearchGenerated.Enabled = false; // Disable the search textbox
            txtSearchGenerated.Clear(); // Clear any text
        }

        private void btnReverseSearch_Click(object sender, EventArgs e)
        {
            string word = txtWordInput.Text.Trim().ToUpperInvariant();

            if (IsValidWord(word))
            {
                var phonewordService = new PhonewordGenerator.BLM.PhonewordService();
                string number = phonewordService.ReverseSearch(word);// Convert word to number

                lstGenerated.Items.Clear();
                lstGenerated.Items.Add($"{word} => {number}");

                // Disable and clear the search textbox since reverse search results are not meant to be searched
                txtSearchGenerated.Enabled = false;
                txtSearchGenerated.Clear();

                statusLabel.Text = "Reverse search complete.";
            }
            else
            {
                MessageBox.Show("Invalid word entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool IsValidWord(string word)
        {
            // Validates the word input
            return !string.IsNullOrEmpty(word) && word.All(char.IsLetter);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add selected items from generated list to selected list
            foreach (var item in lstGenerated.SelectedItems)
            {
                if (!lstSelected.Items.Contains(item))
                {
                    lstSelected.Items.Add(item);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Remove selected items from the selected list
            var selectedItems = lstSelected.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedItems)
            {
                lstSelected.Items.Remove(item);
            }
        }

        // Event handler for the Clear Generated button click
        private void btnClearGenerated_Click(object sender, EventArgs e)
        {
            lstGenerated.Items.Clear(); // Clear generated results list
            _allGeneratedPhonewords.Clear(); // Clear stored generated phonewords
            txtSearchGenerated.Clear(); // Clear search textbox
            txtSearchGenerated.Enabled = false; // Disable generated search textbox
            statusLabel.Text = "Generated phonewords cleared.";
        }

        // Event handler for the Clear Selected button click
        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            lstSelected.Items.Clear();
            statusLabel.Text = "Selected phonewords cleared.";
        }

        // Event handler for the Export button click
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lstSelected.Items.Count > 0)
            {
                // Open a save file dialog to export selected phonewords
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text Files (*.txt)|*.txt";
                    sfd.Title = "Export Phonewords";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var lines = lstSelected.Items.Cast<string>();
                        File.WriteAllLines(sfd.FileName, lines); // Write selected phonewords to file
                        MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                // Show warning if no phonewords are selected for export
                MessageBox.Show("No phonewords selected to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Event handler for the Close button click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for the search textbox text change
        private void txtSearchGenerated_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchGenerated.Text.Trim().ToUpperInvariant();
            FilterGeneratedList(searchText);
        }

        // Filters the generated phonewords list based on the search text
        private void FilterGeneratedList(string searchText)
        {
            if (_allGeneratedPhonewords == null || _allGeneratedPhonewords.Count == 0)
            {
                return; // Do nothing if there are no generated phonewords
            }

            List<string> matchingResults;

            if (string.IsNullOrEmpty(searchText))
            {
                // Display up to maxResultsToDisplay results
                matchingResults = _allGeneratedPhonewords.Take(maxResultsToDisplay).ToList();
            }
            else
            {
                // Filter all generated phonewords
                matchingResults = _allGeneratedPhonewords
                    .Where(pw => pw.Contains(searchText))
                    .ToList();
            }

            // Limit the number of displayed results
            var resultsToDisplay = matchingResults.Take(maxResultsToDisplay).ToList();

            lstGenerated.BeginUpdate();
            lstGenerated.Items.Clear();
            lstGenerated.Items.AddRange(resultsToDisplay.ToArray());
            lstGenerated.EndUpdate();

            // Inform the user if not all matching results are displayed
            if (matchingResults.Count > maxResultsToDisplay)
            {
                MessageBox.Show(
                    $"Displaying the first {maxResultsToDisplay} search results out of {matchingResults.Count} matching entries.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        
    }
}
