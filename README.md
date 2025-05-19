# JWT Tech Task

This is a C# console application that demonstrates the processing of a JSON Web Token (JWT) and the extraction of transaction data from its payload.

## Features

- Decodes a JWT token and extracts the payload as a JSON string
- Deserializes the payload into C# objects using the `System.Text.Json` library
- Processes the user transaction data and prints the following information for each user:
  - User ID
  - Total number of transactions
  - Total amount of confirmed transactions, grouped by currency

## Project Structure

The project consists of the following files:

- `Program.cs`: The main entry point of the application.
- `JwtDecoder.cs`: A helper class that decodes the JWT token and extracts the payload.
- `RootPayload.cs`: A model class representing the root payload structure.
- `UserData.cs`: A model class representing a user's transaction data.
- `Transaction.cs`: A model class representing a single transaction.
- `Meta.cs`: A model class representing the metadata associated with a transaction.

## Acknowledgements

This project was created as a technical task for a fintech application. The requirements and initial code were provided by the project stakeholders.
