class BookSorter
  
  def sort(books)
    sets = []

    sort_in_order(books).each do |b|     
      if sets.any? { |set| set.can_add?(b) }
          add_book(sets, b)
      else
        new_set = BookSet.new
        new_set.add(b)
        sets << new_set
      end
    end
    return sets
  end

  private
  def sort_in_order(books)
    new_list = []
    books.inject(Hash.new(0)) {|h,b| h[b] += 1; h }.
          sort { |x, y| y[1] <=> x[1]}.
          each { |book, count| count.times { || new_list << book} }
    return new_list
  end

  def add_book(sets, book)
    sets.select { |s| s.can_add?(book)}.
         collect { |set| { :set => set, :cost => set.cost_with(book) } }.
         sort { |x, y| x[:cost] <=> y[:cost]}.
         first[:set].add(book)
  end

end