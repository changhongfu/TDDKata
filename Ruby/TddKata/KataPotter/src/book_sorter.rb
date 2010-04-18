class BookSorter
  def sort(books)
    sets = []

    books.each do |b|
      if !has_set_for(sets, b)
        set
      end
    end
    sets << book_set
    return sets
  end

  private
    def has_set?(sets, book)
      sets.each do |s|
        if s.can_add(b)
          return true
        end
      end
      return false
    end
end