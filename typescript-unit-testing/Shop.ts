interface IBasketItem{
    id: string;
    price: number;
    amount?: number;
}

export default class Shop
{
    basket: Array<IBasketItem> = [];
    inventory: Array<IBasketItem> = [];

    constructor(inventory: Array<IBasketItem> = []){
        this.inventory = inventory;
        this.emptyBasket();
    }

    private findInInventory(itemId: string): IBasketItem{
        for(var i: number = 0; i<this.inventory.length; i++){
            if(this.inventory[i].id === itemId)
                return this.inventory[i];
        }

        return null;
    }

    private positionInBasket(itemId: string): number{
        for(var i: number = 0; i<this.basket.length; i++){
            if(this.basket[i].id === itemId)
                return i;
        }

        return -1;
    }

    addToBasket(itemId: string, amount: number = 1): void{
        var item = this.findInInventory(itemId);

        if(item !== null){
            var isAlreadyInTheBasket = this.positionInBasket(itemId);

            if(isAlreadyInTheBasket !== -1){
                this.basket[isAlreadyInTheBasket].amount += amount;
            }
            else{
                item.amount = amount;
                this.basket.push(item);
            }
        }
    }

    getTotal(): number{
        var total: number = 0;

        for(var i: number = 0; i<this.basket.length; i++){        
            // 3 for 2 discount logic
            var amount: number = this.basket[i].amount;
            if(amount > 2){
                amount -= Math.floor(amount / 3);
            }
            // end of: 3 for 2 discount logic

            total += amount * this.basket[i].price;
        }

        return total;
    }

    emptyBasket(): void{
        this.basket = [];
    }
}