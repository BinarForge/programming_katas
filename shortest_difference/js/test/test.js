// No players
var testData0 = [];
var expectedResult0 = false;

QUnit.test("Two players", function( assert ) {
  assert.ok( shortestDifference(testData0) === expectedResult0, "Passed!" );
});

// Just two players
var testData1 = [7,3];
var expectedResult1 = 4;

QUnit.test("Two players", function( assert ) {
  assert.ok( shortestDifference(testData1) === expectedResult1, "Passed!" );
});

// Many players
var testData2 = [7,3,12,6,11,14,5,2,4,7,5,6];
var expectedResult2 = 1;

QUnit.test("Many players", function( assert ) {
  assert.ok( shortestDifference(testData2) === expectedResult2, "Passed!" );
});

// Lots of players
var testData3 = [40,154,25,10,106,136,175,178,46,145,103,169,178,22,46,178,76,73,25,25,157,49,31,160,196,34,13,82,124,112,52,88,115,7,67,139,193,166,196,118,166,40,52,184,184,106,151,172,175,181,79,127,43,1,160,145,25,82,64,169,142,166,19,16,88,58,175,91,127,58,127,124,190,7,163,31,73,85,13,160,178,1,31,46,169,73,64,4,82,154,70,52,112,109,43,52,196,160,172];
var expectedResult3 = 3;

QUnit.test("Lots of players", function( assert ) {
  assert.ok( shortestDifference(testData3) === expectedResult3, "Passed!" );
});

// Almost equal players
// Many players
var testData4 = [3,2,3,4,3,2,1,2,1,3,4];
var expectedResult4 = 0;

QUnit.test("Many players", function( assert ) {
  assert.ok( shortestDifference(testData4) === expectedResult4, "Passed!" );
});