require 'spec'
require 'book_sorter'

describe 'Book sorter' do

  it 'should create one book for one book' do
    book_sorter = BookSorter.new
    sets = book_sorter.sort([:one])
    sets.length.should == 1
    sets[0].books.length.should == 1
  end

  it 'should sort same books into different sets' do
    book_sorter = BookSorter.new
    sets = book_sorter.sort([:one, :one])
    sets.length.should == 2
  end

  it 'should sort into set with best price' do
    book_sorter = BookSorter.new
    sets = book_sorter.sort([:one, :one, :two, :two, :three, :three, :four, :five])
    sets.length.should == 2
    sets[0].books.length.should == 4
    sets[1].books.length.should == 4
  end

  it 'should handle books not in order' do
    book_sorter = BookSorter.new
    sets = book_sorter.sort([:one, :two, :three, :four, :five, :one, :two, :three])
    sets.length.should == 2
    sets[0].books.length.should == 4
    sets[1].books.length.should == 4
  end

end