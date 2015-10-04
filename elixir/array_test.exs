ExUnit.start

defmodule ArrayTest do
  use ExUnit.Case, async: true

  test "create array" do
    assert ["apple", "orange"] = ["apple", "orange"]
  end

  test "add" do
    # http://elixir-lang.org/docs/v1.0/elixir/List.html
    array = List.insert_at([1, 2], 1, 10)
    array = array ++ [3]
    assert [1, 10, 2, 3] = array
  end

  test "get object" do
    # http://elixir-lang.org/docs/v1.0/elixir/Enum.html
    assert "apple" = Enum.at(["apple", "orange"], 0)
  end

  test "get index" do
    assert 0 = Enum.find_index(["apple", "orange"], fn(x)-> x == "apple" end)
    assert nil == Enum.find_index(["apple", "orange"], &(&1 == "not found"))
  end

  test "include" do
    assert Enum.member?(["apple", "orange"], "apple")
  end

  test "remove" do
    array = [1, 2, 3, 4, 4]
    |> List.delete_at(0)
    |> Enum.reject(&(&1 == 4))
    assert [2, 3] = array
  end

  test "each" do
    # Not useful in elixir
    # Enum.each([1, 2], &(IO.puts(&1)))
  end

  test "each with index" do
    # Not useful in elixir
    # array = [1, 2]
    # |> Enum.with_index
    # |> Enum.each(fn {x, i} -> IO.puts "#{x} at #{i}" end)
  end

  test "map" do
    assert [2, 3] = Enum.map([1, 2], &(&1 + 1))
  end

  test "map with index" do
    array = [1, 2]
    |> Enum.with_index
    |> Enum.map(fn {x, i} -> x + i end)
    assert [1, 3] = array
  end

  test "inject" do
    assert 3 = Enum.reduce([1, 2], 0, fn(x, sum) -> x + sum end)
  end

  test "inject with index" do
    assert 2 = [1, 2]
    |> Enum.with_index
    |> Enum.reduce(0, fn ({x, i}, sum) -> sum + x * i end)
  end

  test "select" do
    assert [2] = Enum.filter([1, 2], &(&1 > 1))
  end

  test "compact" do
    assert [1, 2] = Enum.reject([1, nil, 2], &(&1 == nil))
  end

  test "sort" do
    assert [1, 2] = Enum.sort([2, 1])
    assert [2, 1] = Enum.sort_by([1, 2], &(-&1))
    assert [[1, 3], [1, 2], [2, 1]] =
      Enum.sort_by([[2, 1], [1, 3], [1, 2]], fn([a, b]) -> [a, -b] end)
  end

end
