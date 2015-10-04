require 'minitest/autorun'
require 'bigdecimal'

describe "number" do

  it "plus" do
    assert_equal 5, 3 + 2
  end

  it "minus" do
    assert_equal 1, 3 - 2
  end

  it "divide" do
    assert_equal 1, 3 / 2
  end

  it "multiply" do
    assert_equal 6, 3 * 2
  end

  it "remainder" do
    assert_equal 1, 3 % 2
  end

  it "power" do
    assert_equal 9, 3 ** 2
  end

  it "string to number" do
    assert_equal 1, "1".to_i
    assert_equal 0, nil.to_i
    assert_equal 1.1, "1.1".to_f
  end

  it "abs" do
    assert_equal 10, -10.abs
  end

  it "floor" do
    assert_equal 1, 1.3.floor
  end

  it "round" do
    assert_equal 2, 1.5.round
    assert_equal 1.5, 1.54.round(1)
  end

  it "IEEE 754 float" do
    assert_equal 110.00000000000001, 100 * 1.1
    assert_equal 0.30000000000000004, 0.1 + 0.2
  end

  it "accurate float calculation" do
    assert_equal 110, 100 * BigDecimal("1.1")
    assert_equal 0.3, 0.1 + BigDecimal("0.2")
  end

  it "cos" do
    # http://ruby-doc.org/core-2.2.0/Math.html#cos-method
    assert_equal -1, Math.cos(Math::PI)
  end

end
