import { EcommerceService } from './services/ecommerce.service';

const service = new EcommerceService();

service.viewProducts();

service.addToCart(1, 1); // 1 x Laptop
service.addToCart(2, 2); // 2 x Jeans
service.addToCart(3, 1); // 1 x Rice Bag
service.removeFromCart(2); // Remove Jeans

service.showCartSummary();
service.viewProducts();
