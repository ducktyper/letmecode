require 'minitest/autorun'

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

  it "each with index" do
    hash = {name: "apple", price: 3}
    text = ""
    hash.each_with_index {|(k, v), i| text << "#{i}_#{k}_#{v} "}
    assert_equal "0_name_apple 1_price_3 ", text
  end

  it "inject" do
    hash = {name: "apple", price: 3}
    text = hash.inject("") {|t, (k, v)| t + "#{k}_#{v} "}
    assert_equal "name_apple price_3 ", text
  end

  it "inject with index" do
    hash = {name: "apple", price: 3}
    i = 0
    text = hash.inject("") do |t, (k, v)|
      i += 1
      t + "#{i - 1}_#{k}_#{v} "
    end
    assert_equal "0_name_apple 1_price_3 ", text
  end

end
