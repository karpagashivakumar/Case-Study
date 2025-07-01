import { Product } from '../models/product.model';
import { CartItem } from '../models/cart-item.model';
import { Category } from '../models/category.enum';

export class EcommerceService {
    private products: Product[] = [];
    private cart: CartItem[] = [];

    constructor() {
        this.products = [
            { id: 1, name: 'Laptop', price: 45000, stock: 3, category: Category.Electronics },
            { id: 2, name: 'Jeans', price: 1500, stock: 10, category: Category.Clothing },
            { id: 3, name: 'Rice Bag', price: 700, stock: 5, category: Category.Grocery }
        ];
    }

    viewProducts(): void {
        console.log('\nAvailable Products:');
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
    }

    addToCart(productId: number, quantity: number): void {
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
        } else {
            this.cart.push({ product, quantity });
        }

        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.`);
    }

    removeFromCart(productId: number): void {
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

    showCartSummary(): void {
        console.log('\nCart Summary:');
        let total = 0;
        for (const item of this.cart) {
            const lineTotal = item.product.price * item.quantity;
            total += lineTotal;
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
        }

        console.log(`Total: ₹${total}`);

        let discount = 0;
        if (total >= 10000) discount = 0.15;
        else if (total >= 5000) discount = 0.10;

        const discountedTotal = total - (total * discount);
        console.log(`Discounted Total: ₹${discountedTotal}`);
    }

    getProducts(): Product[] {
        return this.products;
    }
}
