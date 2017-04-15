module.exports = {
    arrayNumberSwap: function(data_array, i, j){
        if(i === j)
            return;
            
        data_array[i] = (data_array[j] += data_array[i]) - data_array[i] + (data_array[j] = data_array[i]) - data_array[i];
    }
}