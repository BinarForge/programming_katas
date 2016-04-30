// No players
var testData0 = [];
var expectedResult0 = false;

QUnit.test("No players", function( assert ) {
  assert.ok( shortestDifference(testData0) === expectedResult0, "Wrong!" );
});

// Just two players
var testData1 = [7,3];
var expectedResult1 = 4;

QUnit.test("Two players", function( assert ) {
  assert.ok( shortestDifference(testData1) === expectedResult1, "Wrong!" );
});

// Many players
var testData2 = [7,3,12,6,11,14,0,2,4,17,5];
var expectedResult2 = 1;

QUnit.test("Many players", function( assert ) {
  assert.ok( shortestDifference(testData2) === expectedResult2, "Wrong!" );
});

// Lots of players
var testData3 = [262,55,310,340,10,466,463,25,454,436,442,271,244,166,103,226,280,229,34,424,448,82,481,445,283,457,40,253,61,196,1,157,391,190,223,130,472,415,64,160,88,67,316,139,28,100,418,397,475,469,292,334,247,373,46,145,22,451,202,241,370,409,406,58,208,121,151,124,352,112,178,91,118,238,385,220,136,172,460,364,4,109,493,301,484,328,16,214,289,286,217,439,148,400,70,388,106,193,76,265,319,430,487];
var expectedResult3 = 3;

QUnit.test("Lots of players", function( assert ) {
  assert.ok( shortestDifference(testData3) === expectedResult3, "Wrong!" );
});

// Almost equal players
// Many players
var testData4 = [3,2,3,4,3,2,1,2,1,3,4];
var expectedResult4 = 0;

QUnit.test("Many players", function( assert ) {
  assert.ok( shortestDifference(testData4) === expectedResult4, "Wrong!" );
});