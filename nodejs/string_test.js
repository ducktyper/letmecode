var assert = require('assert');

(function composeString() {
  assert.equal("apple orange", "apple" + " " + "orange");
})();

(function multilineString() {
  var text = [
    "apple",
    "orange",
    ""
  ].join("\n");
  assert.equal("apple\norange\n", text);
})();

(function intToString() {
  assert.equal("1", String(1));
})();

(function regexMatch() {
  // http://www.w3schools.com/js/js_regexp.asp
  assert.equal(0, "apple orange ".match(/apple/)["index"]);
  assert.equal(6, "apple orange ".match(/orange/)["index"]);
  assert.equal(null, "apple orange ".match(/kiwi/));
})();

(function regexMatches() {
  var array = ["apple orange", "apple", "orange"];
  var match = "apple orange ".match(/(apple).*(orange)/);
  assert.equal(3, match.length);
  assert.equal(array[0], match[0]);
  assert.equal(array[1], match[1]);
  assert.equal(array[2], match[2]);
})();

(function concat() {
  var text = "apple";
  var text_backup = text;
  text += " orange ";
  assert.equal("apple orange ", text);
})();

(function concatMutate() {
  // Not possible
})();

(function length() {
  assert.equal(13, "apple orange ".length);
})();

(function format() {
  assert.equal("10.0", 10.001.toFixed(1)); // round
  // http://www.w3schools.com/jsref/jsref_obj_date.asp
  var time  = new Date(2000, 1 - 1, 1, 0, 0, 0);
  var year  = time.getFullYear();
  var month = ("0" + (time.getMonth() + 1)).slice(-2);
  var date  = ("0" + time.getDate()).slice(-2);
  assert.equal("2000-01-01", [year, month, date].join("-"))
})();

(function split() {
  var array = "apple orange ".trim().split(" ");
  assert.equal(2, array.length);
  assert.equal("apple", array[0]);
  assert.equal("orange", array[1]);
})();

(function strip() {
  assert.equal("a b", " a b ".trim());
})();

(function eql() {
  assert.equal(true, "apple" == "apple");
})();
