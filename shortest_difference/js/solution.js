function shortestDifference(valuesArray)
{
	valuesArray.sort();

	var shortest = false;
	for(var i=1; i<valuesArray.length; i++){
		var difference = Math.abs(valuesArray[i] - valuesArray[i-1]);

		if(shortest === false || difference < parseInt(shortest))
			shortest = difference;
	}
	return shortest;
}