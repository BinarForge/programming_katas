function shortestDifference(valuesArray)
{
	var shortest = false;
	for(var i=0; i<valuesArray.length; i++){
		for(var j=0; j<valuesArray.length; j++){
			if(i == j)
				continue;
			
			var difference = Math.abs(valuesArray[i] - valuesArray[j]);

			if(shortest === false || difference < parseInt(shortest))
				shortest = difference;
		}
	}
	return shortest;
}