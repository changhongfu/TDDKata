package test.endtoend.auctionsniper;

import org.junit.Test;

public class AuctionSniperEndToEndTest {
    public final FakeAuctionServer auction = new FakeAuctionServer("item-54321");
    public final ApplicationRunner application = new ApplicationRunner();

    @Test
    public void sniperJoinsAuctionUntilAuctionCloses() throws Exception {
        auction.startSellingItem();
        application.startBiddingIn(auction);
        auction.hasReceievedJoinRequestFromSniper();
        auction.announceClosed();
        application.showSniperHasLostAuction();

    }
}
