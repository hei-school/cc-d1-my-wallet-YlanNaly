package org;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Map;

public class Action implements Serializable {
    private static final long serialVersionUID = 1L;
    private Map<String, WalletModel> wallet;
    private static final String FILENAME = "wallet.ser";

    public Action() {
        wallet = new HashMap<>();
        chargeData();
    }

    private void chargeData() {
        try (ObjectInputStream ois = new ObjectInputStream(Files.newInputStream(Paths.get(FILENAME)))) {
            Object obj = ois.readObject();
            if (obj instanceof Map) {
                wallet = (Map<String, WalletModel>) obj;
            }
        } catch (IOException | ClassNotFoundException e) {
            System.out.println("Impossible de charger les données existantes.");
        }
    }

    private void saveData() {
        try (ObjectOutputStream oos = new ObjectOutputStream(Files.newOutputStream(Paths.get(FILENAME)))) {
            oos.writeObject(wallet);
        } catch (IOException e) {
            System.out.println("Erreur lors de la sauvegarde des données.");
        }
    }

    public void createWallet(String name) {
        wallet.put(name, new WalletModel());
        saveData();
        System.out.println("Portefeuille créé pour " + name);
    }

    public void addSource(String name, double value) {
        WalletModel portefeuille = wallet.get(name);
        if (portefeuille != null) {
            portefeuille.addSource(name, value);
            saveData();
        } else {
            System.out.println("Portefeuille introuvable pour " + name);
        }
    }

    public void expenses(String name, double value) {
        WalletModel portefeuille = wallet.get(name);
        if (portefeuille != null) {
            portefeuille.addExpense(name,value);
        } else {
            System.out.println("Portefeuille introuvable pour " + name);
        }
    }

    public void resetWallet(String name){
        WalletModel portefeuille = wallet.get(name);
        if (portefeuille != null) {
            portefeuille.setAmount(name);
            saveData();
            System.out.println("Portefeuille réinitialisé pour " + name);
        } else {
            System.out.println("Portefeuille introuvable pour " + name);
        }
    }

    public void showWalletModel(String name) {
        WalletModel portefeuille = wallet.get(name);
        if (portefeuille != null) {
            System.out.println("Votre compte est de : "+ portefeuille.getAmountsForWallet(name));
        }
        else{
            System.out.println("Portefeuille introuvable pour " + name);
        }
    }

}
