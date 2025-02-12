# PhonewordGenerator
Phoneword Generator is a Windows Forms application that converts numerical phone numbers into memorable word combinations (phonewords) and supports reverse lookup (converting words back to numbers). Built with a clean two-layer architecture, it separates user interface concerns from the core business logic.

## Features

### Phoneword Generation:
Input a mobile phone number and generate all possible letter combinations based on the telephone keypad mapping.

### Reverse Search:
Convert words back into their numeric phone number equivalents.

### Filtering & Ranking:
Identify and rank meaningful phonewords using a dictionary and custom word lists.

### User-Friendly Interface:
Easily manage generated phonewords with options to add, remove, export, and clear results.

### Robust Error Handling:
Includes input validation and exception management for a smooth user experience.

## Architecture
The application follows a Two-Layer Architecture:

### Presentation Layer (UI):

#### MainForm: Handles user interactions, input validation, and displaying results.
### Business Layer:
#### PhonewordService: Acts as a facade for the business logic.
#### PhonewordGenerator: Generates letter combinations from phone numbers.
#### PartitionGenerator: Creates valid partitions of phone numbers.
#### WordMatcher: Filters and ranks phonewords based on meaningfulness.
#### DigitLetterMapping: Provides digit-to-letter mappings.


## Getting Started
### Prerequisites
Visual Studio (or any compatible IDE) with .NET Framework support.
The project targets a specific version of the .NET Framework (.Net 8.0).

## Installation
### Clone the Repository:
git clone https://github.com/Danyal-Hashemizadeh/PhonewordGenerator.git
### Open the Solution:
Open the project in Visual Studio.

### Build and Run:
Build the solution and start debugging to run the application.

## Documentation
Detailed software architecture and design documentation is available in the Documentation folder.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your improvements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
