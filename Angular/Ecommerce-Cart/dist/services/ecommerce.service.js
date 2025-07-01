"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EcommerceService = void 0;
const category_enum_1 = require("../models/category.enum");
class EcommerceService {
    constructor() {
        this.products = [];
        this.cart = [];
        this.products = [
            { id: 1, name: 'Laptop', price: 45000, stock: 3, category: category_enum_1.Category.Electronics },
            { id: 2, name: 'Jeans', price: 1500, stock: 10, category: category_enum_1.Category.Clothing },
            { id: 3, name: 'Rice Bag', price: 700, stock: 5, category: category_enum_1.Category.Grocery }
        ];
    }
    viewProducts() {
        console.log('\nAvailable Products:');
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
    }
    addToCart(productId, quantity) {
        const product = this.products.find(p => p.id === productId);
        if (!product) {
            console.log("Product not found.");
            return;
        }
        if (product.stock < quantity) {
            console.log(`Not enough stock for ${product.name}.`);
            return;
        }
        const existingItem = this.cart.find(item => item.product.id === productId);
        if (existingItem) {
            existingItem.quantity += quantity;
        }
        else {
            this.cart.push({ product, quantity });
        }
        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.`);
    }
    removeFromCart(productId) {
        const index = this.cart.findIndex(item => item.product.id === productId);
        if (index === -1) {
            console.log("Item not in cart.");
            return;
        }
        const item = this.cart[index];
        item.product.stock += item.quantity; // Restore stock
        this.cart.splice(index, 1);
        console.log(`${item.product.name} removed from cart.`);
    }
    showCartSummary() {
        console.log('\nCart Summary:');
        let total = 0;
        for (const item of this.cart) {
            const lineTotal = item.product.price * item.quantity;
            total += lineTotal;
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
        }
        console.log(`Total: ₹${total}`);
        let discount = 0;
        if (total >= 10000)
            discount = 0.15;
        else if (total >= 5000)
            discount = 0.10;
        const discountedTotal = total - (total * discount);
        console.log(`Discounted Total: ₹${discountedTotal}`);
    }
    getProducts() {
        return this.products;
    }
}
exports.EcommerceService = EcommerceService;
