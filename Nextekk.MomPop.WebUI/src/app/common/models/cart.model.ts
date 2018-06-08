export class Cart {
    constructor(public id: number,
        public name: string,
        public price: number,
        public quantity: number) {
    }

    toDTO(): object {
        return {
            productId: this.id,
            quantity: this.quantity
        };
    }
}
