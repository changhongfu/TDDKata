require 'spec'
require 'book_sorter'

describe 'Book sorter' do

  it 'should sort books' do
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

end