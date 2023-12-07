[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/hy8NMZUz)


## README.md

### Overview

This project demonstrates a simple banking application that manages wallets for multiple users. It includes three main classes: `Action`, `Main`, and `WalletModel`. The `Action` class is responsible for managing the wallets, the `Main` class handles user input and output, and the `WalletModel` class represents a user's wallet.

### Classes and Their Functionality

#### Action.java

The `Action` class is responsible for managing the wallets for multiple users. It includes the following key methods:

- `chargeData()`: Initializes the wallet data from a serialized file.
- `saveData()`: Saves the wallet data to a serialized file.
- `createWallet(String name)`: Creates a new wallet for a user.
- `addSource(String name, String source, double value)`: Adds a new source of revenue for a user.
- `expenses(String name, String source, double value)`: Adds a new expense for a user.
- `resetWallet(String name)`: Resets the wallet balance for a user.
- `showWalletModel(String name)`: Displays the wallet balance for a user.
- `showListExpenses(String name)`: Displays the list of expenses for a user.
- `showListSource(String name)`: Displays the list of sources for a user.

#### Main.java

The `Main` class handles user input and output. It includes a loop that allows users to choose from various options, such as creating a new wallet, adding sources, adding expenses, and displaying the wallet balance, list of expenses, and list of sources. The class uses a `Scanner` to read user input and a `PrintStream` to display the output.

#### WalletModel.java

The `WalletModel` class represents a user's wallet. It includes the following key methods:

- `addSource(String name, String nameSource, double value)`: Adds a new source of revenue to the wallet.
- `addExpense(String name, String nameExpense, double value)`: Adds a new expense to the wallet.
- `getAmountsForWallet(String name)`: Returns the total amount in the wallet for a given user.
- `getListExpense(String name)`: Displays the list of expenses for a user.
- `getListSource(String name)`: Displays the list of sources for a user.
- `setAmount(String value)`: Sets the wallet balance to a given value.

### Serialized Data

The `Action` class saves and loads the wallet data using serialization and deserialization. The data is saved to a file named `wallet.ser` and can be loaded back into a `Map<String, WalletModel>`.

### Notes

- The `WalletModel` class uses a `Map<String, Double>` to represent the wallet's balance and a `Map<String, Double>` to represent the wallet's expenses and sources.
- The `Main` class uses a `Scanner` to read user input and a `PrintStream` to display the output.
- The `Action` class uses serialization and deserialization to save and load the wallet data from a file.
