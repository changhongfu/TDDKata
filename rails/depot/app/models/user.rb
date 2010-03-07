require 'digest/sha1'

class User < ActiveRecord::Base
  validates_presence_of :name
  validates_uniqueness_of :name

  attr_accessor :password_confirmation
  validates_confirmation_of :password

  validate :password_none_blank

  def after_destroy
    if User.count.zero?
      raise "Can't delete last user"
    end
  end

  def password
    @password
  end

  def password=(pwd)
    @password = pwd
    return if pwd.blank?
    create_new_salt
    self.hashed_password = User.encrypted_password(self.password, self.salt)
  end

  def self.authenticate(name, password)
    user = self.find_by_name(name);
    if user
      expected_password = User.encrypted_password(password, user.salt)
      if expected_password != user.hashed_password
        user = nil
      end
    end
    user
  end

  private
    def password_none_blank
      errors.add(:password, "Missing password") if hashed_password.blank? 
    end

    def create_new_salt
      self.salt = self.object_id.to_s + rand.to_s
    end

    def self.encrypted_password(password, salt)
      string_to_hash = password + "wibble" + salt
      Digest::SHA1.hexdigest(string_to_hash)
    end
end
