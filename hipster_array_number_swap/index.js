const assert = require('../common/js/assert')
const hipster = require('./hipster-array-swap')


let array = [1, 2.33, 3.99, 4, 5];

hipster.arrayNumberSwap(array, 3,3);
assert.arraysAreEqual(array, [1, 2.33, 3.99, 4, 5]);

hipster.arrayNumberSwap(array, 0,1);
assert.arraysAreEqual(array, [2.33, 1, 3.99, 4, 5]);

hipster.arrayNumberSwap(array, 1,4);
assert.arraysAreEqual(array, [2.33, 5, 3.99, 4, 1]);

hipster.arrayNumberSwap(array, 0,4);
assert.arraysAreEqual(array, [1, 5, 3.99, 4, 2.33]);