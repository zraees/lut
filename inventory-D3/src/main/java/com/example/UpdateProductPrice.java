package com.example;

import java.util.Scanner;

public class UpdateProductPrice {
    private final InventoryManager inventoryManager;

    public UpdateProductPrice(InventoryManager inventoryManager) {
        this.inventoryManager = inventoryManager;
    }

    public void execute() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter Product ID to Update Price: ");
        int id = scanner.nextInt();
        Product product = inventoryManager.findProductById(id);
        if (product != null) {
            System.out.print("Enter New Price: ");
            double newPrice = scanner.nextDouble();
            product.setPrice(newPrice);
            System.out.println("Product price updated.");
        } else {
            System.out.println("Product not found.");
        }
    }
}