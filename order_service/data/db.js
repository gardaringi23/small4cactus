const orderSchema = require('./schema/order');
const orderItemSchema = require('./schema/orderItem');
const mongoose = require('mongoose');

const connection = mongoose.createConnection('mongodb+srv://hoop-admin:12345@clusterforsmall4.m9qo4.mongodb.net/myFirstDatabase?retryWrites=true&w=majority', {
    useNewUrlParser: true
});

module.exports = {
    Order: connection.model('Order', orderSchema),
    OrderItem: connection.model('OrderItem', orderItemSchema)
};
