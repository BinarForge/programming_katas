var assert = {
    arraysAreEqual: function(arrA, arrB){
        if(arrA.length !== arrB.length)
            throw 'Expected '+JSON.stringify(arrA)+' to be equal to '+JSON.stringify(arrB);

        for(var i=0; i<arrA.length; i++)
            if(arrA[i] !== arrB[i])
                throw 'Expected '+JSON.stringify(arrA)+' to be equal to '+JSON.stringify(arrB) + ' '+arrA[i]+'!='+arrB[i];

        return true;
    }
};

module.exports = assert;