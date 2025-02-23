package com.example;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;

public class InventoryManagerTest {
    private InventoryManager inventoryManager;

    @BeforeEach
    public void setUp() {
        inventoryManager = new InventoryManager();
        inventoryManager.addProduct(new Product(1, "Product One", 8, 10.2));
        inventoryManager.addProduct(new Product(2, "Product Two", 11, 12.4));
        inventoryManager.addProduct(new Product(3, "Product Three", 7, 16.5));
    }

    @Test
    public void testFindProductById() {
        Product foundProduct = inventoryManager.findProductById(3);
        assertEquals("Product Three", foundProduct.getName());
    }

    @Test
    public void testRemoveAllProduct() {
        inventoryManager.removeProduct(1);
        inventoryManager.removeProduct(2);
        inventoryManager.removeProduct(3);
        assertNull(inventoryManager.findProductById(1));
    }
}