require 'minitest/autorun'
require 'active_support/core_ext/hash/slice'
require 'json'

describe "hash" do

  it "create hash" do
    assert_equal({name: "apple", price: 3}, {name: "apple", price: 3}.freeze)
  end

  it "create hash mutable" do
    assert_equal({name: "apple", price: 3}, {name: "apple", price: 3})
    assert_equal({"name" => "apple", "price" => 3}, {"name" => "apple", "price" => 3})
  end

  it "add mutate" do
    hash = {name: "apple"}
    hash[:price] = 3
    assert_equal({name: "apple", price: 3}, hash)
  end

  it "get object" do
    hash = {name: "apple", price: 3}
    assert_equal "apple", hash[:name]
    assert_equal nil, hash[:known]
  end

  it "include key?" do
    hash = {name: "apple", price: 3}
    assert_equal true, hash.include?(:name)
  end

  it "remove mutate" do
    hash = {name: "apple", price: 3}
    hash.delete(:price)
    assert_equal false, hash.include?(:price)
  end

  it "each" do
    hash = {name: "apple", price: 3}
    text = ""
    hash.each {|k, v| text << "#{k}_#{v} "}
    assert_equal "name_apple price_3 ", text
  end

  it "inject" do
    hash = {name: "apple", price: 3}
    text = hash.inject("") {|t, (k, v)| t + "#{k}_#{v} "}
    assert_equal "name_apple price_3 ", text
  end

  it "select" do
    hash = {name: "apple", price: 3}
    assert_equal({name: "apple"}, hash.slice(:name))
  end

  it "select mutate" do
    hash = {name: "apple", price: 3}
    hash.slice!(:name)
    assert_equal({name: "apple"}, hash)
  end

  it "to json" do
    hash = {name: "apple", price: 3}
    assert_equal("{\"name\":\"apple\",\"price\":3}", JSON.generate(hash))
  end

  it "from json" do
    json_string = "{\"name\":\"apple\",\"price\":3}"
    assert_equal({"name" => "apple", "price" => 3}, JSON.parse(json_string))
  end

end
