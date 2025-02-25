package com.example;

import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.io.ByteArrayInputStream;
import java.io.InputStream;

public class UpdateProductPriceTest {
    private InventoryManager inventoryManager;
    private Product product;

    @BeforeEach
    public void setUp() {
        inventoryManager = new InventoryManager();
        product = new Product(1, "MacBook", 15, 1350.0);
        inventoryManager.addProduct(product);
    }

    @Test
    public void testUpdatePrice() {
        // simulate user action / input for updating the product price
        String simulatedInput = "1\n1125.0\n"; // Product ID and New Price
        InputStream in = new ByteArrayInputStream(simulatedInput.getBytes());
        System.setIn(in); // standard system input to the simulated input

        UpdateProductPrice updatePrice = new UpdateProductPrice(inventoryManager);
        updatePrice.execute(); // read from the simulated System.in

        // checking; the product price was updated as expected
        assertEquals(1125.0, product.getPrice(), "Product price should be updated.");
    }
}