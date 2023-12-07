package org;

import java.io.Serializable;
import java.util.*;

public class WalletModel implements Serializable {
    private static final long serialVersionUID = 1L;
    private final Map<String, Double> wallet;

    public WalletModel() {
        wallet = new HashMap<>();
    }

    public void addSource(String name, double value) {
        if (wallet.containsKey(name)) {
            double actualValue = wallet.get(name);
            wallet.put(name, actualValue + value);
        } else {
            wallet.put(name, value);
        }
        System.out.println("Ajouté " + value + " de " + name + " à votre portefeuille.");
    }
    private double calculateTotal(List<Double> list) {
        double total = 0;
        for (double value : list) {
            total += value;
        }
        return total;
    }
    public void addExpense(String name, double value) {
        if (wallet.containsKey(name)) {
            double actualValue = wallet.get(name);
            if(actualValue > value && value > 0.0){
                wallet.put(name, actualValue - value);
                System.out.println("Ajouté " + value + " de dépense " + name + " à votre portefeuille.");
            }
            else if (value < 0.0){
                System.out.println("Dépense 0 ariary ?");
            }
            else if (actualValue < value){
                System.out.println(
                                "Trop peu pour acheter quoi que cela soit : \n"+
                                "Le solde : "+actualValue+"\n"+
                                "Ton soit disant dépense : "+value
                );
            }
        }
    }

    public Double getAmountsForWallet(String name) {
        List<Double> listAmounts = new ArrayList<>();
        for (Map.Entry<String, Double> entry : wallet.entrySet()) {
            if (entry.getKey().startsWith(name)) {
                listAmounts.add(entry.getValue());
            }
        }
        wallet.put(name, calculateTotal(listAmounts));
        return wallet.get(name);
    }

    public void setAmount(String value){
        wallet.put(value, 0.0);
    }
}
