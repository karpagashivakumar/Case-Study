"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ecommerce_service_1 = require("./services/ecommerce.service");
const service = new ecommerce_service_1.EcommerceService();
service.viewProducts();
service.addToCart(1, 1); // 1 x Laptop
service.addToCart(2, 2); // 2 x Jeans
service.addToCart(3, 1); // 1 x Rice Bag
service.removeFromCart(2); // Remove Jeans
service.showCartSummary();
service.viewProducts();
