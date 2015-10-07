var assert = require('assert');

(function plus() {
  assert.equal(5, 3 + 2);
})();

(function minus() {
  assert.equal(1, 3 - 2);
})();

(function divide() {
  assert.equal(1.5, 3 / 2);
})();

(function multiply() {
  assert.equal(6, 3 * 2);
})();

(function remainder() {
  assert.equal(1, 3 % 2);
})();

(function power() {
  assert.equal(9, Math.pow(3, 2));
})();


(function stringToNumber() {
  assert.equal(1, parseInt("1"));
  assert.equal(true, isNaN(parseInt(null)));
  assert.equal(1.1, parseFloat("1.1"));
})();

(function abs() {
  assert.equal(10, Math.abs(-10));
})();

(function floor() {
  assert.equal(1, Math.floor(1.3));
})();

(function round() {
  assert.equal(2, Math.round(1.5));
  assert.equal(1.5, Math.round(1.54 * 10) / 10);
})();


(function ieee754Float() {
  assert.equal(110.00000000000001, 100 * 1.1);
  assert.equal(0.30000000000000004, 0.1 + 0.2);
})();

(function accurateFloatCalculation() {
  // No support
})();

(function cos() {
  // http://www.w3schools.com/jsref/jsref_obj_math.asp
  assert.equal(-1, Math.cos(Math.PI));
})();
