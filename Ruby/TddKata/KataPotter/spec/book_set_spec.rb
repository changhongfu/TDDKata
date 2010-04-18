require 'spec'
require 'book_set'

describe 'Book set' do

  it 'can add a book if it contains no same book' do
    book_set = BookSet.new()
    book_set.can_add?(:one).should == true
    book_set.add(:one)
    book_set.books.include?(:one).should == true
  end

  it 'cannot add a duplicate book' do
    book_set = BookSet.new()
    book_set.add(:one)
    book_set.can_add?(:one).should == false
    lambda { book_set.add(:one) }.should raise_error
  end

  it 'can calculate cost'  do
    book_set = BookSet.new()
    book_set.cost.should == 0
    book_set.add(:one)
    book_set.cost.should == 8
  end

end