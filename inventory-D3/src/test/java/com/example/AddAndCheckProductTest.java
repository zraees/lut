package com.example;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.io.ByteArrayInputStream;
import java.io.InputStream;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class AddAndCheckProductTest {
    private InventoryManager inventoryManager;

    @BeforeEach
    public void setUp() {
        inventoryManager = new InventoryManager();
    }

    @Test
    public void testAddAndViewProduct() {
        // Simulate user action or input
        String simulatedInput = "1\nPlay Station\n20\n315.0\n";
        InputStream in = new ByteArrayInputStream(simulatedInput.getBytes());
        System.setIn(in);

        AddProduct addProduct = new AddProduct(inventoryManager);
        addProduct.execute(); // This will read from System.in, that defined above

        // Checking; the product was added as expected
        assertEquals(1, inventoryManager.getInventory().size());
        Product addedProduct = inventoryManager.getInventory().get(0);
        assertEquals("Play Station", addedProduct.getName());
        assertEquals(20, addedProduct.getQuantity());
        assertEquals(315.0, addedProduct.getPrice());
    }
}