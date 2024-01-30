import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import NavItem from './NavItem'

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <div className="bg-blue-100 font-sans w-full m-0 z-[100] fixed">
            <div className="container mx-auto px-4">
              <div className="flex items-center justify-between py-3">
                <Link to="/">HotelFlow</Link>
                <div className="hidden sm:flex sm:items-center">
                    <NavItem to="/" name='home' />
                    <NavItem to="/find-room" name='znajdź pokój' />
                </div>
                <div className="hidden sm:flex sm:items-center">
                      <Link to="/login" className="text-gray-800 text-sm font-semibold hover:text-blue-600 mr-4">logowanie</Link>
                      <Link to="/register" className="text-gray-800 text-sm font-semibold border-2 border-solid border-blue-900 px-4 py-2 rounded-lg hover:text-blue-600 hover:border-blue-600">rejestracja</Link>
                </div>
            </div>
          </div>
        </div>
      </header>
    );
  }
}
