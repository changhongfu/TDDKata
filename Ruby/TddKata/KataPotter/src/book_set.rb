class BookSet
  def initialize
    @books = []     
  end

  def can_add?(book)
    return !@books.include?(book)
  end

  def add(book)
    raise 'Book already in this set' unless can_add?(book)
    @books << book
  end

  def cost
    return 8 * @books.size * discount
  end

  def cost_with(book)
    new_set = BookSet.new
    @books.each { |b| new_set.add(b) }
    new_set.add(book)
    return new_set.cost
  end

  def books
    return @books
  end
  
  private

  DISCOUNTS = { 0 => 0, 1 => 1.00, 2 => 0.95, 3 => 0.90, 4 => 0.80, 5 => 0.75 }
  
  def discount
      return DISCOUNTS[@books.size]
  end
end