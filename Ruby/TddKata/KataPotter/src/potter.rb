class Potter
  def self.cost(books)
    book_sorter = BookSorter.new
    cost = 0
    book_sorter.sort(books).each { |set| cost += set.cost }
    return cost
  end
end