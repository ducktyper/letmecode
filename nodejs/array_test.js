var assert = require("assert");
// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array

(function createArray() {
  // not supported
})();

(function createArrayMutable() {
  assert.equal(["apple", "orange"], ["apple", "orange"].toString());
})();

(function addMutate() {
  var array = [1, 2];
  array.splice(1, 0, 10);
  array.push(3);
  array.unshift(9);
  assert.equal([9, 1, 10, 2, 3], array.toString());
})();

(function getObject() {
  assert.equal("apple", ["apple", "orange"][0]);
})();

(function getIndex() {
  assert.equal(0, ["apple", "orange"].indexOf("apple"));
  assert.equal(-1, ["apple", "orange"].indexOf("not found"));
})();

(function include() {
  assert.equal(true, ["apple", "orange"].some(e => e === "apple"));
})();

(function removeMutate() {
  var array = [1, 2, 3, 4, 4];
  array.splice(0, 1);
  var i;
  while((i = array.indexOf(4)) !== -1) { array.splice(i, 1) }
  assert.equal([2, 3], array.toString())
})();

(function each() {
  var sum = 0;
  [1, 2].forEach(e => sum += e);
  assert.equal(3, sum);
})();

(function eachWithIndex() {
  var sum = 0;
  var i = 0;
  var array = [1, 2];
  for(i; i < array.length; i++) { sum += array[i] * i }
  assert.equal(2, sum);
})();

(function map() {
  assert.equal([2, 3], [1, 2].map(e => e + 1).toString());
})();

(function mapWithIndex() {
  var i = 0;
  var array = [1, 2].map(function(e) {
    return e + i++;
  });
  assert.equal([1, 3], array.toString());
})();

(function inject() {
  var sum = [1, 2].reduce(function(sum, item, index, array) {
    return sum + item;
  }, 0);
  assert.equal(3, sum);
})();

(function injectWithIndex() {
  var sum = [1, 2].reduce(function(sum, item, index, array) {
    return sum + item * index;
  }, 0);
  assert.equal(2, sum);
})();
