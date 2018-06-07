import { Cart } from "../common/models/cart.model";
import { Component, Input } from "@angular/core";
import { Product } from "../common/models/product.model";

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html'
})
export class CartComponent {
    carts: Cart[];

    @Input()
    show: boolean;

    get totalItems(): number {
        return this.carts.length;
    }

    constructor() {
        this.carts = [];
        this.show = false;
    }

    addItemToCarts(product: Product) {
        const count = this.carts.reduce( (total, cart: Cart) => cart.id == product.id ? total + 1 : total, 0);

        const cart = new Cart(product.id, product.name, product.price, count);

        this.carts.push(cart);
    }
    
}
