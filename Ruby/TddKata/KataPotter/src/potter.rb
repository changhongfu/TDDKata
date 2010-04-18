class Potter
  def self.cost(cart)
    8 * cart.length * discount(cart.length)
  end

  private
  def self.discount(num_books)
      num_books == 1 ? 1 :
      num_books == 2 ? 0.95 :
      num_books == 3 ? 0.90 :
      num_books == 4 ? 0.80 :
      num_books == 5 ? 0.75 :
      0
  end
end