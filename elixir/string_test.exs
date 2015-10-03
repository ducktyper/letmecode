ExUnit.start

defmodule StringTest do
  use ExUnit.Case, async: true

  test "compose string" do
    assert "apple orange" = "#{"apple"} #{"orange"}"
  end

  test "multiline string" do
    text = """
apple
orange
"""
    assert "apple\norange\n" = text
  end

  test "int to string" do
    assert "1", Integer.to_string(1)
  end

  test "regex match" do
    # http://elixir-lang.org/docs/v1.0/elixir/Regex.html
    assert [{0, _}] = Regex.run(~r/apple/, "apple orange ", return: :index)
    assert [{6, _}] = Regex.run(~r/orange/, "apple orange ", return: :index)
    assert nil == Regex.run(~r/kiwi/, "apple orange ", return: :index)
  end

  test "regex matches" do
    assert ["apple orange", "apple", "orange"] =
      Regex.run(~r/(apple).*(orange)/, "apple orange ")
  end

  test "regex replace" do
    assert "orange apple " =
      Regex.replace(~r/(apple).*(orange)/, "apple orange ", "\\2 \\1")
  end

  test "concat" do
    assert "apple orange " = "apple" <> " orange "
  end

  test "concat mutate" do
    # no mutation
  end

  test "length" do
    assert 13 = String.length("apple orange ")
  end

  test "format" do
    # TODO
  end

  test "split" do
    assert ["apple", "orange"] = String.split("apple orange ")
    assert ["apple", "orange "] = String.split("apple,orange ", ",")
  end

  test "strip" do
    assert "a b" = String.strip(" a b ")
  end

  test "eql?" do
    assert "apple" = "apple"
  end

end
