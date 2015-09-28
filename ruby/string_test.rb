require 'minitest/autorun'

describe "string" do

  it "compose string" do
    assert_equal "apple orange", "#{"apple"} #{"orange"}"
  end

  it "multiline string" do
    text = <<-EOS
apple
orange
    EOS
    assert_equal "apple\norange\n", text
  end

  it "int to string" do
    assert_equal "1", 1.to_s
  end

  it "regex match" do
    # http://ruby-doc.org/core-2.2.0/Regexp.html
    assert_equal 0, "apple orange " =~ /apple/
    assert_equal 6, "apple orange " =~ /orange/
    assert_equal nil, "apple orange " =~ /kiwi/
  end

  it "regex matches" do
    assert_equal(
      ["apple orange", "apple", "orange"],
      "apple orange ".match(/(apple).*(orange)/).to_a
    )
  end

  it "regex replace" do
    assert_equal "orange apple ", "apple orange ".gsub(/(apple).*(orange)/, '\2 \1')
  end

  it "concat" do
    text = text_backup = "apple"
    text += " orange "
    assert_equal "apple orange ", text
    assert text != text_backup
  end

  it "concat mutate" do
    text = text_backup = "apple"
    text << " orange "
    assert_equal "apple orange ", text
    assert text.equal?(text_backup)
  end

  it "length" do
    assert_equal 13, "apple orange ".length
  end

  it "format" do
    # http://ruby-doc.org/core-2.2.0/Kernel.html#format-method
    assert_equal "10.0", "%.1f" % 10
    # http://ruby-doc.org/core-2.2.0/Time.html#strftime-method
    assert_equal "2000-01-01", Time.new(2000,1,1).strftime("%Y-%m-%d")
  end

  it "split" do
    assert_equal ["apple", "orange"], "apple orange ".split
    assert_equal ["apple", "orange "], "apple,orange ".split(",")
  end

  it "strip" do
    assert_equal "a b", " a b ".strip
  end

  it "eql?" do
    assert_equal true, "apple" == "apple"
  end

end
