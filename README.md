[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/hy8NMZUz)

### Overview

This project demonstrates a simple banking application that manages wallets for multiple users. It includes three main classes: `Action`, `Main`, and `Model` or `WalletModel`. The `Action` class is responsible for managing the wallets for multiple users. It initializes the wallet data from a serialized file, saves the wallet data to a serialized file, and creates a new wallet for a user. The `Main` class handles user input and output, and the `WalletModel` class represents a user's wallet.

### Classes and Their Functionality

#### Action.py

The `Action` class is responsible for managing the wallets for multiple users. It includes the following key methods:

- `charge_data()`: Initializes the wallet data from a serialized file.
- `save_data()`: Saves the wallet data to a serialized file.
- `create_wallet(name)`: Creates a new wallet for a user.
- `add_source(name, source, value)`: Adds a new source to a user's wallet.
- `expenses(name, name_expense, value)`: Adds a new expense to a user's wallet.
- `reset_wallet(name)`: Resets a user's wallet.
- `show_wallet_model(name)`: Displays the wallet model of a user.
- `show_list_expenses(name)`: Displays the list of expenses of a user.
- `show_list_source(name)`: Displays the list of sources of a user.

#### WalletModel.py

The `WalletModel` class represents a user's wallet. It includes the following methods:

- `__init__()`: Initializes the wallet, deposits, and sources.
- `add_source(name, name_source, value)`: Adds a new source to a user's wallet.
- `add_expense(name, name_expense, value)`: Adds a new expense to a user's wallet.
- `get_amounts_for_wallet(name)`: Calculates the total amount in a user's wallet.
- `get_list_expense(name)`: Displays the list of expenses in a user's wallet.
- `get_list_source(name)`: Displays the list of sources in a user's wallet.
- `set_amount(value)`: Sets the amount in a user's wallet to 0.

#### Main.py

The `Main` class handles user input and output. It includes a loop that allows users to choose from several options, such as creating a new wallet, adding a source, adding an expense, displaying the wallet model, displaying the list of expenses, displaying the list of sources, resetting the wallet, and exiting the program.
