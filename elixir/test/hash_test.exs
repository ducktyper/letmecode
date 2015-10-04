ExUnit.start

defmodule HashTest do
  use ExUnit.Case, async: true

  test "create hash" do
    assert [name: "apple", price: 3] = [name: "apple", price: 3]
    assert %{name: "apple", price: 3} = %{name: "apple", price: 3}
  end

  test "add" do
    hash = %{name: "apple"}
    hash = Dict.put(hash, :price, 3)
    assert %{name: "apple", price: 3} = hash
  end

  test "get object" do
    hash = %{name: "apple", price: 3}
    assert "apple" = Dict.get(hash, :name)
    assert "apple" = hash[:name]
    assert nil == Dict.get(hash, :known)
  end

  test "include key?" do
    hash = %{name: "apple", price: 3}
    assert Dict.has_key?(hash, :name)
  end

  test "remove" do
    hash = %{name: "apple", price: 3}
    hash = Dict.delete(hash, :price)
    assert !Dict.has_key?(hash, :price)
  end

  test "each" do
    # Not useful in elixir
    # hash = %{name: "apple", price: 3}
    # Enum.each(hash, fn {k, v} -> IO.puts("#{k}_#{v}") end)
  end

  test "inject" do
    hash = %{name: "apple", price: 3}
    text = Enum.reduce(hash, "", fn({k, v}, text) -> "#{text}#{k}_#{v} " end)
    assert  "name_apple price_3 " = text
  end

  test "select" do
    hash = %{name: "apple", price: 3}
    assert %{name: "apple"} = Dict.take(hash, [:name])
  end

  test "to json" do
    # https://github.com/devinus/poison
    hash = %{name: "apple", price: 3}
    assert "{\"price\":3,\"name\":\"apple\"}" = Poison.encode!(hash)
  end

  test "from json" do
    json_string = ~s({"name":"apple","price":3})
    assert %{"name" => "apple", "price" => 3} = Poison.decode!(json_string)
  end

end
