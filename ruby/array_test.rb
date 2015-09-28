require 'minitest/autorun'

describe "array" do

  it "create array" do
    assert_equal ["apple", "orange"], ["apple", "orange"].freeze
  end

  it "create array mutable" do
    assert_equal ["apple", "orange"], %w{apple orange}
    assert_equal ["apple", "orange"], "apple orange".split
    assert_equal ["apple", "orange"], ["apple", "orange"]
  end

  it "add mutate" do
    array = [1, 2]
    array.insert(1, 10)
    array << 3
    assert_equal [1, 10, 2, 3], array
  end

  it "get object" do
    assert_equal "apple", ["apple", "orange"][0]
  end

  it "get index" do
    assert_equal 0, ["apple", "orange"].index("apple")
    assert_equal nil, ["apple", "orange"].index("not found")
  end

  it "include" do
    assert_equal true, ["apple", "orange"].include?("apple")
  end

  it "remove mutate" do
    array = [1, 2, 3, 4, 4]
    array.delete_at(0)
    array.delete(4)
    assert_equal [2, 3], array
  end

  it "each" do
    sum = 0
    [1, 2].each {|x| sum += x}
    assert_equal 3, sum
  end

  it "each with index" do
    sum = 0
    [1, 2].each_with_index {|x, i| sum += x * i}
    assert_equal 2, sum
  end

  it "map" do
    assert_equal [2, 3], [1, 2].map {|x| x + 1}
  end

  it "map with index" do
    assert_equal [1, 3], [1, 2].each_with_index.map {|x, i| x + i}
  end

  it "inject" do
    assert_equal 3, [1, 2].inject(0) {|sum, x| sum + x}
  end

  it "inject with index" do
    assert_equal 2, [1, 2].each_with_index.inject(0) {|sum, (x, i)| sum + x * i}
  end

  it "select" do
    assert_equal [2], [1, 2].select {|x| x > 1}
  end

  it "select mutate" do
    array = [1, 2]
    array.select! {|x| x > 1}
    assert_equal [2], array
  end

  it "compact" do
    assert_equal [1, 2], [1, nil, 2].compact
  end

  it "compact mutate" do
    array = [1, nil, 2]
    object_id = array.object_id
    array.compact!
    assert_equal [1, 2], array
    assert_equal object_id, array.object_id
  end

  it "sort" do
    assert_equal [1, 2], [2, 1].sort
    assert_equal [2, 1], [1, 2].sort_by {|x| -x}
    assert_equal [[1, 3], [1, 2], [2, 1]],
      [[2, 1], [1, 3], [1, 2]].sort_by {|x| [x.first, -x.last]}
    assert_equal [1, 2], [2, 1].sort {|a, b| b == a ? 0 : (a > b ? 1 : -1)}
  end

end
