import { expect } from 'chai'
import Shop from './Shop'


describe('Given the Shop instance with no products', () => {
    var shop: Shop = new Shop();

    describe('When initialising with an empty basket', () => {
        it('Then the total equals zero', () => {
            expect(shop.getTotal()).to.equal(0.00);
        })
    })
})

describe('Given the Shop instance with few products defined', () => {
    var shop: Shop = new Shop([
        {id: 'apple', price: 1.50},
        {id: 'banana', price: 2.30}
    ]);

    describe('When purchasing a single item', () => {
        shop.addToBasket('apple', 1);

        it('Then no discounts are applied', () => {
            expect(shop.getTotal()).to.equal(1.50);
        })
    })
})

describe('Given the Shop instance with few products defined', () => {
    var shop: Shop = new Shop([
        {id: 'apple', price: 1.50},
        {id: 'banana', price: 2.30}
    ]);

    describe('When purchasing three items of the same kind', () => {
        shop.addToBasket('apple', 1);
        shop.addToBasket('banana', 1);
        shop.addToBasket('apple', 2);

        it('Then the "3 for 2" discount is applied', () => {
            expect(shop.getTotal()).to.equal(5.30);
        })
    })
})