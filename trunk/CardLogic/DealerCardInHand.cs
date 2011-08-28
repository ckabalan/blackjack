﻿//-----------------------------------------------------------------------
// <copyright file="CardInHand.cs" company="SpectralCoding">
//		Copyright (c) SpectralCoding. All rights reserved.
//		Repeatedly violating our Copyright (c) will bring the full
//		extent of the law, which may ultimately result in permanent
//		imprisonment at hard labor, and/or death by extreme slow
//		torture, and/or lethal experimental medical therapies.
// </copyright>
// <author>Caesar Kabalan</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BlackJack.Utilities;
using BlackJack.ViewModel;

namespace BlackJack.CardLogic {
	/// <summary>
	/// Represents a card's metadata.
	/// </summary>
	public class DealerCardInHand : ViewModelBase {
		#region Private Fields
		private Card m_Card;
		private Point m_Position = new Point(0, 0);
		private DealerHandViewModel m_Parent;
		private TableViewModel m_MasterParent;
		private bool m_IsShowing;
		#endregion
		
		#region Public Properties
		public Point Position {
			get { return m_Position; }
			private set {
				m_Position = value;
				OnPropertyChanged("Position");
			}
		}
		/// <summary>
		/// Gets a value indicating the card that this contains.
		/// </summary>
		public Card Card {
			get { return m_Card; }
			private set {
				m_Card = value;
				OnPropertyChanged("Card");
			}
		}
		/// <summary>
		/// Gets a value indicating the BitmapSource which represents the card image.
		/// </summary>
		public BitmapSource CardImage {
			get {
				if (IsShowing) {
					return m_MasterParent.ResourcesVM.CardImages[m_Card.ShortTitle];
				} else {
					return m_MasterParent.ResourcesVM.CardImages["Back_Red"];
				}
			}
		}
		public bool IsShowing {
			get {
				return m_IsShowing;
			}
			set {
				if (m_IsShowing != value) {
					m_IsShowing = value;
					OnPropertyChanged("CardImage");
					OnPropertyChanged("CardImage");
					OnPropertyChanged("IsShowing");
				}
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the CardInHand class.
		/// </summary>
		/// <param name="Parent">Placeholder for the Parent object.</param>
		/// <param name="BaseCard">The card in which to hold this class's data.</param>
		public DealerCardInHand(DealerHandViewModel Parent, TableViewModel MasterParent, Card BaseCard, bool ShowCard) {
			m_MasterParent = MasterParent;
			m_Parent = Parent;
			m_Card = BaseCard;
			m_IsShowing = ShowCard;
			OnPropertyChanged("CardImage");
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Sets the Position property of the CardInHand class to the appropriate coordinates depending on what position the card is in.
		/// </summary>
		/// <param name="CardNumber">The position of the card in the hand.</param>
		public void SetPosition(int CardNumber, int TotalCards) {
			Position = new Point(700 - ((80.0 * CardNumber) + 383.0 - ((TotalCards - 1) * 40)), 0.0);
		}
		#endregion
	}
}
