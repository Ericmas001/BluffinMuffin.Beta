package poker.game.observer;

import poker.game.MoneyPot;
import poker.game.PlayerInfo;
import poker.game.TypeAction;
import poker.game.TypeRound;
import utility.EventObserver;

public class PokerGameObserver extends EventObserver<IPokerGameListener> implements IPokerGameListener
{
    @Override
    public void gameBlindsNeeded()
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.gameBlindsNeeded();
        }
    }
    
    @Override
    public void playerJoined(PlayerInfo p)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerJoined(p);
        }
    }
    
    @Override
    public void playerLeaved(PlayerInfo p)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerLeaved(p);
        }
    }
    
    @Override
    public void playerActionNeeded(PlayerInfo p)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerActionNeeded(p);
        }
    }
    
    @Override
    public void gameBettingRoundStarted()
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.gameBettingRoundStarted();
        }
    }
    
    @Override
    public void everythingEnded()
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.everythingEnded();
        }
    }
    
    @Override
    public void playerMoneyChanged(PlayerInfo p)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerMoneyChanged(p);
        }
    }
    
    @Override
    public void playerActionTaken(PlayerInfo p, TypeAction reason, int playedAmount)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerActionTaken(p, reason, playedAmount);
        }
    }
    
    @Override
    public void gameEnded()
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.gameEnded();
        }
    }
    
    @Override
    public void playerWonPot(PlayerInfo p, MoneyPot pot, int wonAmount)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerWonPot(p, pot, wonAmount);
        }
    }
    
    @Override
    public void gameBettingRoundEnded(TypeRound r)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.gameBettingRoundEnded(r);
        }
    }
    
    @Override
    public void playerHoleCardsChanged(PlayerInfo p)
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.playerHoleCardsChanged(p);
        }
    }
    
    @Override
    public void gameGenerallyUpdated()
    {
        for (final IPokerGameListener listener : getSubscribers())
        {
            listener.gameGenerallyUpdated();
        }
    }
}
