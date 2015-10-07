ExUnit.start

defmodule NumberTest do
  use ExUnit.Case, async: true

  test "plus" do
    assert 3 + 2 = 5
  end

  test "minus" do
    assert 3 - 2 = 1
  end

  test "divide" do
    assert 3 / 2 = 1.5
  end

  test "multiply" do
    assert 3 * 2 = 6
  end

  test "remainder" do
    assert 1 = rem 3, 2
  end

  test "power" do
    assert 9.0 = :math.pow 3, 2
  end

  test "string to number" do
    assert {1, _} = Integer.parse("1")
    assert :error = Integer.parse("")
    assert {1.1, _} = Float.parse("1.1")
  end

  test "abs" do
    assert 10 = abs(-10)
  end

  test "floor" do
    assert 1.0 = Float.floor(1.3)
  end

  test "round" do
    assert 2.0 = Float.round(1.5)
    assert 1.5 = Float.round(1.54, 1)
  end

  test "IEEE 754 float" do
    assert 110.00000000000001 = 100 * 1.1
    assert 0.30000000000000004 = 0.1 + 0.2
  end

  test "accurate float calculation" do
    # no support
  end

  test "cos" do
    assert -1.0 = :math.cos(:math.pi)
  end

end
