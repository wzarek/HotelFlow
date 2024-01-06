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
        <div className="bg-gray-100 font-sans w-full m-0">
          <div className="bg-white shadow">
            <div className="container mx-auto px-4">
              <div className="flex items-center justify-between py-3">
                <Link to="/">HotelFlow</Link>
                <div className="hidden sm:flex sm:items-center">
                    <NavItem to="/" name='Home' />
                    <NavItem to="/counter" name='Counter' />
                </div>
                <div className="hidden sm:flex sm:items-center">
                      <a href="#" className="text-gray-800 text-sm font-semibold hover:text-blue-600 mr-4">Sign in</a>
                      <a href="#" className="text-gray-800 text-sm font-semibold border px-4 py-2 rounded-lg hover:text-blue-600 hover:border-blue-600">Sign up</a>
                    </div>
              </div>
            </div>
          </div>
        </div>
      </header>
    );
  }
}
