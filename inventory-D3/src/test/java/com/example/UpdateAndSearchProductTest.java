package com.example;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.io.ByteArrayInputStream;
import java.io.InputStream;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class UpdateAndSearchProductTest {
    private InventoryManager inventoryManager;

    @BeforeEach
    public void setUp() {
        inventoryManager = new InventoryManager();
    }

    @Test
    public void testAddAndViewProduct() {
        // Prepare simulated user input for adding a product
        String simulatedInput = "1\nNew Product\n10\n15.0\n"; // Product ID, Name, Quantity, Price
        InputStream in = new ByteArrayInputStream(simulatedInput.getBytes());
        System.setIn(in); // Redirect standard input to the simulated input

        // Create an instance of AddProduct and execute the method
        AddProduct addProduct = new AddProduct(inventoryManager);
        addProduct.execute(); // This will read from the redirected System.in

        // Verify that the product was added to the inventory
        assertEquals(1, inventoryManager.getInventory().size(), "Inventory size should be 1 after adding a product.");
        
        // Retrieve the added product and verify its properties
        Product addedProduct = inventoryManager.getInventory().get(0);
        assertEquals("New Product", addedProduct.getName(), "Product name should match the input.");
        assertEquals(10, addedProduct.getQuantity(), "Product quantity should match the input.");
        assertEquals(15.0, addedProduct.getPrice(), "Product price should match the input.");
    }
}