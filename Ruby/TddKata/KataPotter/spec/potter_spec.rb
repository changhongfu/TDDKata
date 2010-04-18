require 'spec'
require 'potter'

describe 'when calculate cost' do

  it "should calculate cost of empty cart" do
    Potter.cost([]).should == 0
  end

  it 'should calculate one book' do
    Potter.cost([:one]).should == 8
    Potter.cost([:two]).should == 8
    Potter.cost([:three]).should == 8
    Potter.cost([:four]).should == 8
    Potter.cost([:five]).should == 8
  end

  it 'should calculate two books' do
    Potter.cost([:one, :two]).should == 8 * 2 * 0.95
    Potter.cost([:one, :three]).should == 8 * 2 * 0.95
    Potter.cost([:one, :five]).should == 8 * 2 * 0.95
    Potter.cost([:four, :five]).should == 8 * 2 * 0.95

  end

  it 'should calculate three books' do
    Potter.cost([:one, :two, :three]).should == 8 * 3 * 0.90
    Potter.cost([:one, :two, :five]).should == 8 * 3 * 0.90
    Potter.cost([:three, :four, :five]).should == 8 * 3 * 0.90
  end

  it 'should calculate four books' do
    Potter.cost([:one, :two, :three, :four]).should == 8 * 4 * 0.80
    Potter.cost([:two, :three, :four, :five]).should == 8 * 4 * 0.80
  end

  it 'should calculate five books' do
    Potter.cost([:one, :two, :three, :four, :five]).should == 8 * 5 * 0.75
  end
end