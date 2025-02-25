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
        inventoryManager.addProduct(new Product(1, "Product One", 8, 10.2));
    }

    @Test
    public void testAddAndCheckProduct() {
        // simulate user action / input for updating a product
        String simulatedInput = "1\n120\n"; // Product ID, Name, Quantity, Price
        InputStream in = new ByteArrayInputStream(simulatedInput.getBytes());
        System.setIn(in); // pointing standard input to the simulated input

        // Create an object of UpdateQuantity and exec the method 
        UpdateQuantity updateQuantity = new UpdateQuantity(inventoryManager);
        updateQuantity.execute();   // This will read from the redirected System.in

        // checking that the product is successfully added
        assertEquals(1, inventoryManager.getInventory().size(), "Inventory size equals to 1 after adding this product.");
        
        // Fetch the recently updated product and checking its properties
        Product updatedProduct = inventoryManager.getInventory().get(0);
        assertEquals(120, updatedProduct.getQuantity(), "Product quantity is matching with the input.");
        
    }
}