package com.example;

import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class ProductTest {
    private Product product;

    @BeforeEach
    public void setUp() {
        product = new Product(1, "IBM Laptop", 50, 3110.0);
    }

    @Test
    public void testGetId() {
        assertEquals(1, product.getId());
    }
}